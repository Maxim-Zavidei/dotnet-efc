docker image build -t pg-ch2 .
# run container in backgroudn with generated image
docker container run -d --name pg-ch2 -p 5432:5432 pg-ch2

