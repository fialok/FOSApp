node('magic') {

    stage('Checkout') {
       
            checkout scm
        if("${env.JOB_NAME}" != "TestJobSinglePipeline") {
            currentBuild.displayName = "${env.BRANCH_NAME}-${env.BUILD_NUMBER}"
            
        } else {
            currentBuild.displayName = "${env.BUILD_TAG}"
            
        }
            echo "Test Echo - run more tests"
            sh "env"
            sh "sudo docker --version"
        
  }
    stage('BuildImage') {
        echo "Creating docker image from docker file"
    }
    stage('RunImage') {
        echo "Creating docker image from docker file"
    }
 
}
