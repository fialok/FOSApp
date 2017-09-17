node('magic') {

    stage('Checkout') {
       
            checkout scm
        if(${env.JOB_NAME} != "TestJobSinglePipeline") {
            currentBuild.displayName = "${env.BRANCH_NAME}-${env.BUILD_NUMBER}"
            
        } else {
            currentBuild.displayName = "${env.TAG_NAME}"
            
        }
            echo "Test Echo - run more tests"
            sh "env"
        
      
  }
    stage('Compile') {
        echo "Compiling source code now"
    }
 
}
