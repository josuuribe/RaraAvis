docker build -t joursain/raspberry-build-tensorflow -f Dockerfile.tensorflow . && docker run -v /var/run/docker.sock:/var/run/docker.sock joursain/raspberry-build-tensorflow
