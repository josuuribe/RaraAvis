FROM ubuntu:latest

# 1. Environment vars
ARG DEBIAN_FRONTEND=noninteractive
ARG TZ=Europe/Madrid
ENV TZ=$TZ
ENV NODE_OPTIONS=--max-old-space-size=768

# 2. Install packages
# 2.1 Update system and install Jupyter
RUN apt-get update && apt-get -y upgrade && \
        apt-get install -y --no-install-recommends libhdf5-dev && \
        apt-get install -y --no-install-recommends tzdata && \
        apt-get install -y --no-install-recommends libzbar-dev libzbar0 && \
        apt-get install -y --no-install-recommends build-essential python3-pip python3-dev python3-venv && \
        apt-get install -y --no-install-recommends git && \
        apt-get install -y --no-install-recommends software-properties-common && \
        python3 -m pip install --upgrade virtualenv && \
        python3 -m pip install --upgrade wheel && \
        python3 -m pip install --upgrade ipykernel && \
        python3 -m pip install --upgrade pip && \
        python3 -m pip install --upgrade setuptools && \
# 2.2 Build git extension
        python3 -m pip install jupyter && \
        apt-get install -y --no-install-recommends nodejs && \
        apt-get install -y --no-install-recommends npm && \
        python3 -m pip install jupyterlab && \
        python3 -m pip install --upgrade jupyterlab-git && \     
        jupyter lab build --minimize=False && \
# 2.3 Clean
        apt-get clean && \
        rm -rf /var/lib/apt/lists/* && \
        rm -rf /tmp/*

# 3 Install TensorFlow
RUN python3 -m pip install --no-cache-dir --force-reinstall grpcio
# 3.1 Install Tensorflow 1 for Python 3.7
RUN add-apt-repository ppa:deadsnakes/ppa
RUN apt-get install -y python3.7 python3.7-dev python3.7-venv
RUN python3.7 -m pip install --upgrade pip && python3.7 -m pip install setuptools
COPY tensorflow-1.14.0-cp37-none-linux_armv7l.whl ./
RUN python3.7 -m pip install tensorflow-1.14.0-cp37-none-linux_armv7l.whl
# 3.2 Install Tensorflow 2 for Python 3.8
COPY tensorflow-2.4.0rc0-cp38-none-linux_armv7l.whl ./
RUN python3 -m pip install tensorflow-2.4.0rc0-cp38-none-linux_armv7l.whl  

# 4. Add Jupyter user
RUN adduser --disabled-password --gecos '' jupyter
RUN adduser jupyter sudo
RUN echo '%sudo ALL=(ALL) NOPASSWD:ALL' >> /etc/sudoers
USER jupyter
WORKDIR /home/jupyter/
RUN chmod a+rwx /home/jupyter/

# 5. Folder to download git files
RUN mkdir /home/jupyter/notebooks

# 6. Create virtual environments
SHELL ["/bin/bash", "-c"]

RUN mkdir /home/jupyter/notebooks/tf1
WORKDIR /home/jupyter/notebooks/tf1
RUN /usr/bin/python3.7 -m venv env 
RUN source env/bin/activate && \
	python3 -m pip install --upgrade pip && \
	python3 -m pip install --upgrade setuptools && \
	python3 -m pip install --upgrade wheel && \
	python3 -m pip install --no-cache-dir --force-reinstall grpcio && \
	python3 -m pip install ipykernel && \
        python3 -m pip install /tensorflow-1.14.0-cp37-none-linux_armv7l.whl && \
        python3 -m pip install pandas && \
	python3 -m ipykernel install --user --display-name='Python 3.7 TensorFlow 1.4' --name=envpy37tf14 && \
	deactivate

RUN mkdir /home/jupyter/notebooks/tf2
WORKDIR /home/jupyter/notebooks/tf2
RUN /usr/bin/python3.8 -m venv env
RUN source env/bin/activate && \
        python3 -m pip install --upgrade pip && \
        python3 -m pip install --upgrade setuptools && \
        python3 -m pip install --upgrade wheel && \
        python3 -m pip install --no-cache-dir --force-reinstall grpcio && \
        python3 -m pip install ipykernel && \
        python3 -m pip install /tensorflow-2.4.0rc0-cp38-none-linux_armv7l.whl && \
        python3 -m pip install pandas && \
        python3 -m ipykernel install --user --display-name='Python 3.8 TensorFlow 2.4rc4' --name=envpy38tf24rc4 && \
        deactivate

#Second option using paths (no nested)
	#ENV VIRTUAL_ENV=/home/jupyter/notebooks/tf1
	#RUN python3.7 -m venv $VIRTUAL_ENV
	#ENV PATH="$VIRTUAL_ENV/bin:$PATH"
	#RUN python3 -m pip install --upgrade pip
	#RUN python3 -m pip install --upgrade setuptools
	#RUN python3 -m pip install --upgrade wheel
	#RUN python3 -m pip install --no-cache-dir --force-reinstall grpcio
	#RUN python3 -m pip install ipykernel
	#RUN python3 -m pip install /tensorflow-1.14.0-cp37-none-linux_armv7l.whl
	#RUN python3 -m ipykernel install --user --display-name='Python 3.7 TensorFlow 1.4' --name=envpy37tf14

	#RUN mkdir /home/jupyter/notebooks/tf2
	#WORKDIR /home/jupyter/notebooks/tf2
	#ENV VIRTUAL_ENV=/home/jupyter/tf2
	#RUN python3.8 -m venv $VIRTUAL_ENV
	#ENV PATH="$VIRTUAL_ENV/bin:$PATH"
	#RUN python3 -m pip install --upgrade pip
	#RUN python3 -m pip install --upgrade setuptools
	#RUN python3 -m pip install --upgrade wheel
	#RUN python3 -m pip install --no-cache-dir --force-reinstall grpcio
	#RUN python3 -m pip install ipykernel
	#RUN python3 -m pip install /tensorflow-2.4.0rc0-cp38-none-linux_armv7l.whl
	#RUN python3 -m ipykernel install --user --display-name='Python 3.8 TensorFlow 2.4rc4' --name=envpy38tf24rc4

# 6. Execute jupyter
#CMD ["jupyter", "lab", "--port=8888", "--no-browser", "--ip=0.0.0.0", "--allow-root", "--notebook-dir=/home/jupyter/notebooks", "--NotebookApp.token=''", "--NotebookApp.password=''"]

