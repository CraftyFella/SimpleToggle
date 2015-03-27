// include Fake lib
#r "packages/FAKE/tools/FakeLib.dll"
open Fake

// Properties
let solutionFile = "SimpleToggle.sln"
let testDir = "./test/"
let testDlls = !!"/**/bin/Release/*Tests.dll"

Target "Build" (fun _ ->
    !! solutionFile
      |> MSBuildRelease "" "Build"
      |> Log "AppBuild-Output: "
)

Target "Test" (fun _ ->
    testDlls
      |> xUnit (fun p ->
          {p with
             ToolPath = "packages/xunit.runner.console/tools/xunit.console.exe";
             OutputDir = testDir;
              })
)

Target "Default" (fun _ ->
    trace "Hello World from FAKE"
)

// Dependencies
"Build"
  ==> "Test"
  ==> "Default"

// start build
RunTargetOrDefault "Default"