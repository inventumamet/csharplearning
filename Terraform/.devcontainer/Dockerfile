# See here for image contents: https://github.com/microsoft/vscode-dev-containers/tree/v0.166.1/containers/dotnet/.devcontainer/base.Dockerfile
ARG VARIANT="5.0"

FROM hashicorp/terraform:latest AS terraform_image

# [Choice] .NET version: 5.0, 3.1, 2.1

FROM mcr.microsoft.com/vscode/devcontainers/dotnetcore:0-${VARIANT}
COPY --from=terraform_image /bin/terraform /bin/

# [Option] Install Node.js
ARG INSTALL_NODE="true"
ARG NODE_VERSION="lts/*"
RUN if [ "${INSTALL_NODE}" = "true" ]; then su vscode -c "umask 0002 && . /usr/local/share/nvm/nvm.sh && nvm install ${NODE_VERSION} 2>&1"; fi

# [Option] Install Azure CLI
ARG INSTALL_AZURE_CLI="false"
COPY library-scripts/azcli-debian.sh /tmp/library-scripts/
RUN if [ "$INSTALL_AZURE_CLI" = "true" ]; then bash /tmp/library-scripts/azcli-debian.sh; fi \
    && apt-get clean -y && rm -rf /var/lib/apt/lists/* /tmp/library-scripts

# [Optional] Uncomment this section to install additional OS packages.
# RUN apt-get update && export DEBIAN_FRONTEND=noninteractive \
#     && apt-get -y install --no-install-recommends <your-package-list-here>

# [Optional] Uncomment this line to install global node packages.
# RUN su vscode -c "source /usr/local/share/nvm/nvm.sh && npm install -g <your-package-here>" 2>&1

# Install AWSCLI V2
RUN curl "https://awscli.amazonaws.com/awscli-exe-linux-x86_64.zip" -o "awscliv2.zip" \
    && unzip awscliv2.zip \
    && sudo ./aws/install


# copy over credentials
RUN mkdir /root/.aws/
COPY credentials /root/.aws/
COPY config /root/.aws/