// include Fake lib
#r "packages/FAKE/tools/FakeLib.dll"

open Fake

// Properties
let solutionFile = "SimpleToggle.sln"
let testDir = "./test/"
let packageDir = "./package/"
let testDlls = !!"/**/bin/Release/*Tests.dll"
let xUnitPath = "packages/xunit.runner.console/tools/xunit.console.exe"
let nugetKey = environVar "NUGETKEY"
let nugetUrl = environVar "NUGETURL"

let buildNumber = 
    match appVeyorBuildVersion with
    | null -> "0.0.0"
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
                 OutputPath = packageDir })
    let consoleOut = System.Console.Out
    System.IO.TextWriter.Null |> System.Console.SetOut
    Paket.Push(fun p -> 
        { p with ApiKey = nugetKey
                 PublishUrl = nugetUrl
                 WorkingDir = packageDir })
    System.Console.SetOut consoleOut)
Target "Default" DoNothing
Target "CI" DoNothing
// Dependencies
"Build" ==> "Test" ==> "Default"
"Build" ==> "Test" ==> "NuGet" ==> "CI"
// start build
RunTargetOrDefault "Default"
