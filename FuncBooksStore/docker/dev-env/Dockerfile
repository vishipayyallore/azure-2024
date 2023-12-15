# [Choice] .NET version: 7.0, 6.0, 5.0, 3.1, 6.0-bullseye, 5.0-bullseye, 3.1-bullseye, 6.0-focal, 5.0-focal, 3.1-focal, 8.0-bullseye
ARG DOTNET_VARIANT="1-8.0-bookworm"
FROM mcr.microsoft.com/devcontainers/dotnet:${DOTNET_VARIANT}

# [Optional] Uncomment this section to install additional OS packages.
RUN apt-get update && \
    export DEBIAN_FRONTEND=noninteractive && \
    apt-get -qy full-upgrade && \
    apt-get install -qy curl && \
    apt-get -y install --no-install-recommends vim && \
    curl -sSL https://get.docker.com/ | sh

RUN curl https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.gpg && \
    mv microsoft.gpg /etc/apt/trusted.gpg.d/microsoft.gpg && \
    sh -c 'echo "deb [arch=amd64] https://packages.microsoft.com/debian/11/prod bullseye main" > /etc/apt/sources.list.d/dotnetdev.list'

# [Optional] Uncomment this section to install additional OS packages.
RUN apt-get update && \
    export DEBIAN_FRONTEND=noninteractive && \
    apt-get -y install --no-install-recommends  \
    azure-functions-core-tools-4

RUN dotnet tool install -g dotnet-ef

ENV PATH $PATH:/root/.dotnet/tools

# configure for https
RUN dotnet dev-certs https
