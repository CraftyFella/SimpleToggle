// include Fake lib
#r "packages/FAKE/tools/FakeLib.dll"

open Fake

// Properties
let solutionFile = "SimpleToggle.sln"
let testDir = "./test/"
let packageDir = "./package/"
let testDlls = !!"/**/bin/Release/*Tests.dll"
let xUnitPath = "packages/xunit.runner.console/tools/xunit.console.exe"

let buildNumber = 
    match appVeyorBuildVersion with
    | null -> "0.0.2"
    | _ -> appVeyorBuildVersion

Target "Build" (fun _ -> 
    !!solutionFile
    |> MSBuildRelease "" "Build"
    |> Log "AppBuild-Output: ")
Target "Test" (fun _ -> 
    testDlls |> xUnit (fun p -> 
                    { p with ToolPath = xUnitPath
                             OutputDir = testDir }))

Target "NuGet" (fun _ -> 
    Paket.Pack(fun p -> 
        { p with Version = buildNumber
                 OutputPath = packageDir }))
Target "Default" DoNothing
Target "CI" DoNothing
// Dependencies
"Build" ==> "Test" ==> "Default"
"Build" ==> "Test" ==> "NuGet" ==> "CI"
// start build
RunTargetOrDefault "Default"
