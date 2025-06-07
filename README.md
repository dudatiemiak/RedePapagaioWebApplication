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

                         +----------------------+
                         |    T_PPG_REGIAO      |
                         +----------------------+
                         | PK id_regiao         |
                         | nm_regiao            |
                         | nm_cidade            |
                         | nm_estado            |
                         | nm_pais              |
                         +----------------------+
                                  |
                                  | FK
                                  |
                         +----------------------+
                         |  T_PPG_OCORRENCIA    |
                         +----------------------+
                         | PK id_ocorrencia     |
                         | FK id_status_ocorrencia
                         | FK id_nivel_urgencia |
                         | FK id_regiao         |
                         | FK id_tipo_ocorrencia|
                         | ds_ocorrencia        |
                         +----------------------+
                                  |
                                  | FK
                                  |
                         +------------------------+
                         |  T_PPG_AJUDA_REALIZADA |
                         +------------------------+
                         | PK id_ajuda            |
                         | FK id_usuario          |
                         | FK id_ocorrencia       |
                         | FK id_tipo_ajuda       |
                         | ds_ajuda               |
                         | dt_ajuda               |
                         +------------------------+

+--------------------------+       +--------------------------+
|    T_PPG_STATUS_OCORRENCIA |     |    T_PPG_TIPO_OCORRENCIA  |
+--------------------------+       +--------------------------+
| PK id_status_ocorrencia   |       | PK id_tipo_ocorrencia     |
| UQ nm_status              |       | UQ nm_tipo_ocorrencia      |
+--------------------------+       +--------------------------+

+--------------------------+       +------------------------+
|   T_PPG_NIVEL_URGENCIA    |       |   T_PPG_TIPO_AJUDA     |
+--------------------------+       +------------------------+
| PK id_nivel_urgencia      |       | PK id_tipo_ajuda        |
| UQ nm_nivel               |       | UQ nm_tipo_ajuda         |
+--------------------------+       +------------------------+

                         +----------------------+
                         |    T_PPG_USUARIO     |
                         +----------------------+
                         | PK id_usuario        |
                         | nm_usuario           |
                         | UQ nm_email          |
                         | nm_senha             |
                         | dt_cadastro          |
                         +----------------------+
                                  |
                                  | FK
                                  |
                         +---------------------+
                         |   T_PPG_TELEFONE    |
                         +---------------------+
                         | PK id_telefone      |
                         | nr_telefone         |
                         | nr_ddd              |
                         | nr_ddi              |
                         | FK id_usuario       |
                         +---------------------+
