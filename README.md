# Rewriting the content and ensuring the code block is complete

readme_content = """
# **RedePapagaio: Sistema de Controle de Desastres Naturais**

## **Visão Geral**

O **RedePapagaio** é um sistema desenvolvido para o controle de ocorrências de desastres naturais, gerenciar a ajuda realizada pelos usuários e conectar ONGs e voluntários a regiões afetadas. O sistema possui uma API RESTful, projetada com **.NET 8** e utiliza **Oracle** como banco de dados. O projeto foi desenvolvido com ênfase na escalabilidade e usabilidade para cenários de desastres.

---

## **Tecnologias Utilizadas**

- **Backend**: .NET 8 (C#)
- **Banco de Dados**: Oracle Database
- **ORM**: Entity Framework Core
- **API Documentation**: Swagger
- **Injeção de Dependência**: ASP.NET Core DI
- **Testes**: XUnit (Testes Unitários)

---

## **Arquitetura do Sistema**

O sistema é composto por várias entidades inter-relacionadas, como **Usuário**, **Ocorrência**, **AjudaRealizada**, **Região**, **TipoOcorrencia** e **StatusOcorrencia**. Cada entidade possui relacionamentos de 1:N ou N:M com outras entidades, conforme a lógica do sistema.

### **Diagramas**

Aqui estão os diagramas que ilustram a arquitetura do sistema:

#### **Diagrama de Classes**

```mermaid
erDiagram
    T_PPG_REGIAO {
        int id_regiao PK
        string nm_regiao
        string nm_cidade
        string nm_estado
        string nm_pais
    }

    T_PPG_OCORRENCIA {
        int id_ocorrencia PK
        string ds_ocorrencia
        int id_status_ocorrencia FK
        int id_nivel_urgencia FK
        int id_regiao FK
        int id_tipo_ocorrencia FK
    }

    T_PPG_AJUDA_REALIZADA {
        int id_ajuda PK
        string ds_ajuda
        datetime dt_ajuda
        int id_usuario FK
        int id_ocorrencia FK
        int id_tipo_ajuda FK
    }

    T_PPG_STATUS_OCORRENCIA {
        int id_status_ocorrencia PK
        string nm_status
    }

    T_PPG_TIPO_OCORRENCIA {
        int id_tipo_ocorrencia PK
        string nm_tipo_ocorrencia
    }

    T_PPG_NIVEL_URGENCIA {
        int id_nivel_urgencia PK
        string nm_nivel
    }

    T_PPG_TIPO_AJUDA {
        int id_tipo_ajuda PK
        string nm_tipo_ajuda
    }

    T_PPG_USUARIO {
        int id_usuario PK
        string nm_usuario
        string nm_email
        string nm_senha
        datetime dt_cadastro
    }

    T_PPG_TELEFONE {
        int id_telefone PK
        string nr_telefone
        string nr_ddd
        string nr_ddi
        int id_usuario FK
    }

    T_PPG_REGIAO ||--o| T_PPG_OCORRENCIA : "Contém"
    T_PPG_OCORRENCIA ||--o| T_PPG_AJUDA_REALIZADA : "Gerada por"
    T_PPG_STATUS_OCORRENCIA ||--o| T_PPG_OCORRENCIA : "Determina Status"
    T_PPG_TIPO_OCORRENCIA ||--o| T_PPG_OCORRENCIA : "Define Tipo"
    T_PPG_NIVEL_URGENCIA ||--o| T_PPG_OCORRENCIA : "Define Urgência"
    T_PPG_TIPO_AJUDA ||--o| T_PPG_AJUDA_REALIZADA : "Classifica Ajuda"
    T_PPG_USUARIO ||--o| T_PPG_AJUDA_REALIZADA : "Realiza"
    T_PPG_USUARIO ||--o| T_PPG_TELEFONE : "Possui"
```

---

###Desenvolvimento
       - O projeto segue a arquitetura MVC (Model-View-Controller) e utiliza o Entity Framework Core para a manipulação dos dados no banco Oracle. Cada recurso da API é acessado via HTTP Requests, e o Swagger é utilizado para documentar as rotas.

---

###Configuração de banco de dados 
    - Aqui está um exemplo de configuração do arquivo `appsettings.json` para o banco de dados. **Lembre-se de substituir os valores de usuário, senha, servidor e porta**:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "User Id=<SEU_USUARIO>;Password=<SUA_SENHA>;Data Source=<SEU_SERVIDOR>:<PORTA>/<SERVICO>"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```
---

###Intruções de execução: 
 - Faça o clone do repositório
```bash
git clone https://github.com/username/redepapagaio.git
cd redepapagaio
```

 - Execute esse comando para restaurar as dependencias:
```bash
dotnet restore
```

 - Para compilar o projeto, execute:
```bash
dotnet build
```

 - Para rodar a aplicação, execute:
```bash
dotnet run
```

---

###Acessar o Swagger:
    - Abra o navegador e vá até http://localhost:5169, onde você verá a interface do Swagger. A partir daí, você pode testar as rotas da API diretamente.
    
