rm rpiplay.out 2>/dev/null
nohup docker build -t joursain/rpi-build-rpiplay -f Dockerfile.rpiplay . > rpiplay.out &
sleep 10
tail -fn 20 rpiplay.out

