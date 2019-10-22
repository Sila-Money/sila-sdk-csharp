node {
	stage 'Checkout'
		checkout scm

	stage 'Build'
		dotnet build

	stage 'Archive'
		archive 'SilaAPI/bin/Release/**'

}