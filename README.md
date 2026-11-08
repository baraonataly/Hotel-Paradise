# 🏨 Hotel Paradise

API REST para gerenciamento de hotel, desenvolvida em **C#** para a disciplina de **Desenvolvimento de Software Visual**.

## 📌 Descrição

O **Hotel Paradise** é um sistema que permite gerenciar hóspedes, quartos e reservas por meio de requisições HTTP.

A aplicação utiliza **ASP.NET Core Minimal API** para disponibilizar os endpoints e **Entity Framework Core** para realizar a comunicação com o banco de dados SQLite, garantindo a persistência das informações.

O projeto tem como objetivo aplicar conceitos de programação orientada a objetos, desenvolvimento de APIs e persistência de dados.

## 👥 Integrantes

- Nátaly Barão
- Stephany Ramina

## ⚙️ Funcionalidades

### Hóspedes

- Cadastro de hóspedes;
- Listagem de hóspedes;
- Busca de hóspede por ID;
- Atualização de dados;
- Exclusão de hóspedes.

### Quartos

- Cadastro de quartos;
- Listagem de quartos;
- Exclusão de quartos, com verificação de reservas vinculadas.

### Reservas

- Cadastro de reservas;
- Listagem de reservas;
- Cancelamento de reservas;
- Validação das datas;
- Verificação de conflitos de reservas para o mesmo quarto;
- Cálculo automático do valor total da hospedagem.

## 🧩 Estrutura do projeto

O projeto está organizado da seguinte forma:

- **Program.cs** — configuração da aplicação e definição dos endpoints da API;
- **Models/** — classes que representam Hóspede, Quarto e Reserva;
- **AppDbContext.cs** — contexto responsável pela comunicação com o banco de dados;
- **Migrations/** — arquivos de migração utilizados para criar e atualizar a estrutura do banco de dados;
- **hotelparadise.db** — banco de dados SQLite utilizado pela aplicação.

## 🛠️ Tecnologias

- **C#**
- **.NET**
- **ASP.NET Core Minimal API**
- **Entity Framework Core**
- **SQLite**
- **Git**
- **GitHub**
- **Postman** — utilizado para testar os endpoints.

## ▶️ Como executar

1. Clone este repositório.
2. Certifique-se de possuir o **.NET SDK** instalado.
3. Abra o terminal na pasta raiz do projeto.
4. Restaure as dependências:

   ```bash
   dotnet restore HotelParadiseAPI/HotelParadiseAPI.csproj
   ```

5. Execute a API:

   ```bash
   dotnet run --project HotelParadiseAPI/HotelParadiseAPI.csproj
   ```

6. Utilize o Postman para enviar requisições HTTP aos endpoints disponibilizados pela aplicação.

O endereço local da API será informado no terminal após a execução.
