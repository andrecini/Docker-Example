# Projeto de Treinamento de Docker

Para fins de estudo, foi desenvolvido um projeto de Web API ASP.NER Core 6 com um Crud de usuários que está hospedado na Azure via Docker compose com a sua imagem (nesse link: [andrecini/treinamentoocker](https://hub.docker.com/repository/docker/andrecini/treinamentodocker/general)) e com a imagem do SQL 5.7.43.

## Tecnologias Utilizadas
- Asp Net Core (.Net 6.0)
- Dapper
- MySql
- XUnit
- Moq
- Azure (Serviços de Aplicativos)
- Docker (Docker Hub e Docker Compose)

## Como testar o compose?

1 - Clique com o Botão direito no projeto da API e adicione um Container Ochestrator Support.
![image](https://github.com/andrecini/Docker-Example/assets/79148213/cefbd587-8fb9-4b21-bb41-6803af78fae3)

2 - Altere o conteúdo do Arquivo Docker-Compose.yml para conteúdo do arquivo na pasta "Docker\Docker Compose\DockerComposebase.yml"

3- Defina o Projeto Docker-Compose como Startup Project

