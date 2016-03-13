# NuGetPackageTutorial
Demonstration of how you can setup your own NuGet Package and push/deploy into your NuGet Server.

The steps of creating NuGet package are very well documented at: https://docs.nuget.org/create/creating-and-publishing-a-package
My tutorial should only lift the burden of creating the solution and to get up and running fast in a NuGet aware ecosystem.

**Create a NuGet Package**

	- Download NuGet.exe from : https://dist.nuget.org/win-x86-commandline/latest/nuget.exe
	- Make sure NuGet.exe is in your path. I put the nuget.exe in C:\NugetPackager. Then
	  created a new system environment variable:
	  
	  NUGET_PACKAGER_HOME = C:\NugetPackager
	  
	  and added that variable to the PATH variable like
	  
	  PATH = . . . /%NUGET_PACKAGER_HOME%
	  
	- In the project "StringExtensions.NuGet" I added a post-build event in the project properties 
	
	  cd $(ProjectDir)
	  nuget spec
	  
	  This creates a special nuspec file with tokens meant to be replaced at pack time based on the 
	  project metadata.
	  	  
		Token				Source
		$id$				The Assembly name
		$version$			The assembly version as specified in the assembly’s AssemblyVersionAttribute 
							(or	AssemblyInformationalVersionAttribute if present).
		$author$			The company as specified in the AssemblyCompanyAttribute.
		$description$		The description as specified in the AssemblyDescriptionAttribute.

		
	- Pack the project. Add that line below the above post-build instructions.
	
	  nuget pack -Symbols $(ProjectPath)
	  
	  Every time the project is compiled an updated .nupkg file gets generated with the information
	  set in the projects AssemblyInfo.cs.
	  
	 - Push the nuget package into your NuGet Server
	 
	   nuget push *.nupkg -s http://localhost/NuGetServerBuild/
	  
	   Note: http://localhost/NuGetServerBuild/ is the virtual path of your NuGet Server. Specify your path here.
