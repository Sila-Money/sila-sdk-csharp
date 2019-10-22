node {
	stage 'Checkout'
		checkout scm

	stage 'Build'
		./build.sh

	stage 'Archive'
		archive 'SilaAPI/bin/Release/**'

}