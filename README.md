
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
 - Inserindo uma região
![Exemplo](RedePapagaioWebApplication/img/teste_regiao_1.png)
- Buscando todos
![Exemplo](RedePapagaioWebApplication/img/teste_regiao_2.png)
- Buscando por id
![Exemplo](RedePapagaioWebApplication/img/teste_regiao_3.png)
- Atualizando
![Exemplo](RedePapagaioWebApplication/img/teste_regiao_4.png)
- Deletando
![Exemplo](RedePapagaioWebApplication/img/teste_regiao_5.png)

### AjudaRealizada
 - Inserindo uma ajuda realizada
![Exemplo](RedePapagaioWebApplication/img/teste_ajuda_1.png)
 - Buscando todas
![Exemplo](RedePapagaioWebApplication/img/teste_ajuda_2.png)
 - Buscando por id
![Exemplo](RedePapagaioWebApplication/img/teste_ajuda_3.png)
 - Atualizando
![Exemplo](RedePapagaioWebApplication/img/teste_ajuda_4.png)
 - Deletando
![Exemplo](RedePapagaioWebApplication/img/teste_ajuda_5.png)
 - Buscando ajuda realizada por id de usuário
![Exemplo](RedePapagaioWebApplication/img/teste_ajuda_6.png)
 - Buscando ajuda realizada por id de ocorrência
![Exemplo](RedePapagaioWebApplication/img/teste_ajuda_7.png)

### Ocorrencia
 - Inserindo ocorrencia
![Exemplo](RedePapagaioWebApplication/img/teste_ocorrencia_1.png)
 - Buscando todas
![Exemplo](RedePapagaioWebApplication/img/teste_ocorrencia_2.png)
 - Buscando ocorrencia por id
![Exemplo](RedePapagaioWebApplication/img/teste_ocorrencia_3.png)
 - Atualizando 
![Exemplo](RedePapagaioWebApplication/img/teste_ocorrencia_4.png)
 - Deletando
![Exemplo](RedePapagaioWebApplication/img/teste_ocorrencia_5.png)
 - Buscando ocorrencia por id de status
![Exemplo](RedePapagaioWebApplication/img/teste_ocorrencia_6.png)
 - Buscando ocorrencia por id de nivel urgencia
![Exemplo](RedePapagaioWebApplication/img/teste_ocorrencia_7.png)
 - Buscando ocorrencia por id de tipo ocorrencia
![Exemplo](RedePapagaioWebApplication/img/teste_ocorrencia_8.png)

### Status 
 - Inserindo
![Exemplo](RedePapagaioWebApplication/img/teste_status_1.png)
 - Buscando todos
![Exemplo](RedePapagaioWebApplication/img/teste_status_2.png)
 - Buscando por id
![Exemplo](RedePapagaioWebApplication/img/teste_status_3.png)
 - Atualizando
![Exemplo](RedePapagaioWebApplication/img/teste_status_4.png)
 - Deletando
![Exemplo](RedePapagaioWebApplication/img/teste_status_5.png)

### Telefone
 - Inserindo
![Exemplo](RedePapagaioWebApplication/img/telefone_1.png)
 - Buscando todos
![Exemplo](RedePapagaioWebApplication/img/telefone_2.png)
 - Buscando por id
![Exemplo](RedePapagaioWebApplication/img/telefone_3.png)
  - Atualizando
![Exemplo](RedePapagaioWebApplication/img/telefone_4.png)
 - Deletando
![Exemplo](RedePapagaioWebApplication/img/telefone_5.png)
 - Buscando telefone por id de usuario
![Exemplo](RedePapagaioWebApplication/img/telefone_6.png)

### TipoAjuda
 - Inserindo
![Exemplo](RedePapagaioWebApplication/img/tpa_1.png)
 - Buscando todos
![Exemplo](RedePapagaioWebApplication/img/tpa_2.png)
 - Buscando por id
![Exemplo](RedePapagaioWebApplication/img/tpa_3.png)
 - Atualizando
![Exemplo](RedePapagaioWebApplication/img/tpa_4.png)
 - Deletando
![Exemplo](RedePapagaioWebApplication/img/tpa_5.png)

### TipoOcorrencia
 - Inserindo
![Exemplo](RedePapagaioWebApplication/img/tpo_1.png)
 - Buscando por todos
![Exemplo](RedePapagaioWebApplication/img/tpo_2.png)
 - Buscando por id
![Exemplo](RedePapagaioWebApplication/img/tpo_3.png)
- Atualizando
![Exemplo](RedePapagaioWebApplication/img/tpo_4.png)
 - Deletando
![Exemplo](RedePapagaioWebApplication/img/tpo_5.png)

### NivelUrgencia
 - Inserindo
![Exemplo](RedePapagaioWebApplication/img/urgencia_1.png)
 - Buscando por todos
![Exemplo](RedePapagaioWebApplication/img/urgencia_2.png)
 - Buscando por id
![Exemplo](RedePapagaioWebApplication/img/urgencia_3.png)
 - Atualizando
![Exemplo](RedePapagaioWebApplication/img/urgencia_4.png)
 - Deletando
![Exemplo](RedePapagaioWebApplication/img/urgencia_5.png)

### Usuario
 - Inserindo
![Exemplo](RedePapagaioWebApplication/img/usuario_1.png)
 - Buscando por todos
![Exemplo](RedePapagaioWebApplication/img/usuario_2.png)
 - Buscando por id
![Exemplo](RedePapagaioWebApplication/img/usuario_3.png)
 - Atualizando
![Exemplo](RedePapagaioWebApplication/img/usuario_4.png)
 - Deletando
![Exemplo](RedePapagaioWebApplication/img/usuario_5.png)
 - Buscando usuario por nome
![Exemplo](RedePapagaioWebApplication/img/usuario_6.png)

---

## 👨‍💻 Integrantes do Grupo

| Nome                                      | RM       | Turma  |
|-------------------------------------------|----------|--------|
| Eduarda Tiemi Akamini Machado             | 554756   | 2TDSPH |
| Felipe Pizzinato Bigatto                  | 555141   | 2TDSPH |
| Gustavo de Oliveira Turci Sandrini        | 557505   | 2TDSPW |

---
