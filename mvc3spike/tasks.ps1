properties { 
    $sln_file          =  "mvc3spike.sln"
    $website_folder    =  "src\web"
    $base_directory    =  resolve-path .
    $tools_directory   =  "$base_directory\tools"
    $build_directory   =  "$base_directory\build"
    $publish_directory =  "\\MyWebServer\website"
    $publish_user      =  "deployment"
    $publish_pass      =  "password"
    $local_test_runner =  "C:\Program Files\NUnit 2.5.1\bin\net-2.0\nunit-console.exe"    
    $unittest_project  =  "$build_directory\UnitTests.dll"
} 

Task default -Depends Test 

Task Test -Depends Compile, Clean {
“This is a test”
}

Task Compile -Depends Clean {

    Trace-Command NativeCommandParameterBinder {
        Exec { msbuild $sln_file /t:Build /p:Configuration=Debug /v:quiet /p:OutDir=$build_directory } 
    } -PsHost
}

Task Clean {
“Clean”
}



