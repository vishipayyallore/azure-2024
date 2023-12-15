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

# [Optional] Uncomment this section to install additional OS packages.
RUN apt-get update \
    && export DEBIAN_FRONTEND=noninteractive \
    && apt-get -y install --no-install-recommends \
    azure-functions-core-tools-3 \
    azure-functions-core-tools-4

# Install Azure Functions Extension
RUN su vscode -c "code --install-extension ms-azuretools.vscode-azurefunctions"

RUN dotnet tool install -g dotnet-ef

ENV PATH $PATH:/root/.dotnet/tools

# configure for https
RUN dotnet dev-certs https
