rm ai.out 2>/dev/null
nohup docker build -t joursain/rpi-jupyterlab-ai:buster -f Dockerfile.ai-jupyterlab . > ai.out &
sleep 10
tail -fn 20 ai.out


