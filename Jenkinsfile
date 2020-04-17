pipeline {
    agent none
    environment {
        DOTNET_CLI_HOME = "/tmp/DOTNET_CLI_HOME"
        SONAR_SCANNER_HOME = "/tmp/DOTNET_CLI_HOME/.dotnet/tools"
    }
    stages {
        stage('.Net Core 2.1') {
            agent {
                docker {
                    image 'mcr.microsoft.com/dotnet/core/sdk:2.1-stretch'
                    args '-u root'
                }
            }
            steps {
                sh 'dotnet build /p:TargetFrameworks=netcoreapp2.1'
                withCredentials([string(credentialsId: 'sila-private-key', variable: 'SILA_PRIVATE_KEY')]) {
                    sh 'dotnet test --no-build -v n /p:TargetFrameworks=netcoreapp2.1'
                }
            }
        }
        stage('.Net Core 3.0') {
            agent {
                dockerfile {
                    args '-u root'
                }
            }
            steps {
                sh 'dotnet tool install --global dotnet-sonarscanner --version 4.8.0'
                withSonarQubeEnv('GekoSonar') {
                    sh "${SONAR_SCANNER_HOME}/dotnet-sonarscanner begin /k:SilaSDKC /d:sonar.cs.opencover.reportsPaths=\"**/*.opencover.xml\""
                    sh 'dotnet build /p:TargetFrameworks=netcoreapp3.0'
                    withCredentials([string(credentialsId: 'sila-private-key', variable: 'SILA_PRIVATE_KEY')]) {
                        sh 'dotnet test --no-build -v n --collect:"XPlat Code Coverage" --settings coverlet.runsettings /p:TargetFrameworks=netcoreapp3.0'
                    }
                    sh "${SONAR_SCANNER_HOME}/dotnet-sonarscanner end"
                }
            }
        }
        stage("Quality Gate") {
            agent none
            steps {
                timeout(time: 1, unit: 'HOURS') {
                    waitForQualityGate abortPipeline: true
                }
            }
        }
    }
}