### Arrow

Execute with:  
docker run -dit _image_id_

Copy wheel from docker image:  
docker cp _container_id_:/drop .

Now, you can stop container:  
docker container stop _container_id_

It works for Apache 4.0.0 (master) and also for latest stable version (3.0.0) anyway you can switch versions using ARROW_TAG while build (set as value the same label as exists in Arrow GitHub repository)

### Pytorch

Execute with:  
docker run -dit _image_id_

Copy wheel from docker image:  
docker cp _container_id_:/drop .

Now, you can stop container:  
docker container stop _container_id_

It works for Pytorch 1.8.0, anyway you can switch versions using PYTORCH_TAG while build (set as value the same label as exists in Pytorch GitHub repository)

