rm ai.out 2>/dev/null
nohup docker build -t joursain/rpi-jupyterlab-ai -f Dockerfile.ai . > ai.out &
sleep 10
tail -f ai.out
