$prefixRepo = "thiagonetorj/controle-d:latest" 
docker image build -t $prefixRepo .\docker\web
docker image push $prefixRepo