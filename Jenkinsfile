node() {

    stage('Checkout') {
      checkout scm
      currentBuild.displayName = "${env.BRANCH_NAME}-${env.BUILD_NUMBER}"
      echo "Test Echo - run more tests"
  }
 
}
