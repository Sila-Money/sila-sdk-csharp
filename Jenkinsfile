node {
	stage 'Checkout'
		checkout scm

	stage 'Build'
		bat 'nuget restore SilaAPI.sln'
		bat "\"${tool 'MSBuild'}\" SilaAPI.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"

	stage 'Archive'
		archive 'SilaAPI/bin/Release/**'

}