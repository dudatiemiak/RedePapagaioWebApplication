
# 🌐 **RedePapagaio: Sistema de Controle de Desastres Naturais**

## 📌 Visão Geral

O **RedePapagaio** é um sistema desenvolvido para o controle de ocorrências de desastres naturais, gerenciamento de ajuda realizada por usuários e conexão entre ONGs, voluntários e regiões afetadas.  
A API RESTful foi construída com **.NET 8** e utiliza **Oracle Database**, prezando pela **escalabilidade** e **usabilidade** em cenários emergenciais.

---

## 🧰 Tecnologias Utilizadas

- ✅ **Backend**: .NET 8 (C#)  
- ✅ **Banco de Dados**: Oracle Database  
- ✅ **ORM**: Entity Framework Core  
- ✅ **Documentação da API**: Swagger  

---

## 📐 Diagramas

### 🧩 Diagrama Relacional (Mermaid)

> Representação das entidades, atributos e seus relacionamentos no banco de dados:

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

## 🧱 Estrutura do Projeto

- O projeto segue o padrão de arquitetura **MVC (Model-View-Controller)**.
- Utiliza o **Entity Framework Core** para manipulação dos dados no Oracle.
- Cada recurso da API é acessado via **HTTP Requests**.
- A documentação das rotas é gerada automaticamente via **Swagger**.

---

## ⚙️ Configuração do Banco de Dados

> Exemplo do arquivo `appsettings.json` com a string de conexão:

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

> 🔐 **Atenção**: Lembre-se de substituir `<SEU_USUARIO>`, `<SUA_SENHA>`, `<SEU_SERVIDOR>`, `<PORTA>` e `<SERVICO>` com os dados reais.

---

## 🚀 Instruções de Execução

### 1. Clone o repositório

```bash
git clone https://github.com/username/redepapagaio.git
cd redepapagaio
```

### 2. Restaure as dependências

```bash
dotnet restore
```

### 3. Compile o projeto

```bash
dotnet build
```

### 4. Execute a aplicação

```bash
dotnet run
```

---

## 🌍 Acesso ao Swagger

- Após rodar a aplicação, acesse:  
  👉 [http://localhost:5169](http://localhost:5169)  
- A interface do Swagger será exibida, permitindo testar todas as rotas da API de forma visual e interativa.

---

## Testes

---

### Regiao

![Exemplo](img/Captura de tela 2025-06-08 091837.png)
