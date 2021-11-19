rm pytorch.out 2>/dev/null
nohup docker build --build-arg PYTORCH_TAG=v1.10.0 -t joursain/rpi-build-pytorch -f Dockerfile.pytorch . > pytorch.out &
sleep 10
tail -fn 20 pytorch.out
