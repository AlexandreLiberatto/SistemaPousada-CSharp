# Sistema de Gestão de Reservas para Pousada

Este é um sistema de gestão de reservas desenvolvido para uma pousada em Tubarão, Santa Catarina. Este projeto foi criado durante o curso de Análise e Desenvolvimento de Sistemas da Universidade UNISENAI SC como parte das atividades do quarto semestre. 

O sistema é um software desktop desenvolvido em C# e MySQL, e abrange uma ampla gama de funcionalidades, como cadastros, movimentações, reservas e relatórios. Ele é ideal para gerenciar reservas, estoque de produtos, entrada e saída de hóspedes e outras atividades da pousada.

## Funcionalidades

### Sessão de Cadastros
- **Funcionários, Hóspedes, Quartos, Usuários, Produtos, Serviços, Cargos e Fornecedores**: Permite o cadastro e a gestão de diferentes entidades.
- **Produtos**: Possui recursos para adicionar novos produtos e atualizar o estoque.

### Sessão de Movimentações
- **Vendas e Serviços**: Cadastro de vendas e de novos tipos de serviços.
- **Controle de Entradas e Saídas**: Consulta de movimentações de entrada e saída.

### Sessão de Reservas
- **Reservas de Quartos**: Formulário com calendário, visualização de quartos disponíveis (quartos ocupados aparecem em vermelho) e campos para inserir informações do hóspede, como telefone, nome e valor da diária.
- **Consulta de Reservas**: Ferramenta para visualizar, realizar check-ins e check-outs.

### Sessão de Relatórios
- **Relatórios de Produtos, Vendas, Serviços e Movimentações Gerais**: Relatórios detalhados, com opção para exportação em PDF, Excel e Word.

---

## Pré-requisitos

Certifique-se de que os seguintes programas estão instalados no seu ambiente local:
- [Visual Studio](https://visualstudio.microsoft.com/) com suporte para C# e Windows Forms.
- [XAMPP](https://www.apachefriends.org/) para rodar o servidor MySQL localmente.
- [PHPMyAdmin](https://www.phpmyadmin.net/) para gerenciar o banco de dados MySQL.

---

## Instalação e Configuração

### Passo 1: Clone o Repositório
Para começar, clone este repositório na sua máquina local:
```bash
git clone https://github.com/AlexandreLiberatto/SistemaPousada-CSharp.git
cd SistemaPousada-CSharp
```

### Passo 2: Configuração do Banco de Dados
1. Abra o XAMPP e inicie o servidor MySQL.
2. Acesse o PHPMyAdmin (geralmente em [http://localhost/phpmyadmin](http://localhost/phpmyadmin)).
3. Crie um novo banco de dados chamado `hotel`.
4. Importe o arquivo `hotel.sql` (disponível no repositório) para o banco de dados `hotel`.

### Passo 3: Configuração do Projeto no Visual Studio
1. Abra o Visual Studio e carregue a solução do projeto (`.sln`) localizada na pasta do repositório.
2. Verifique se a conexão com o banco de dados está configurada corretamente no código, apontando para o banco de dados local criado no passo anterior.
3. Compile o projeto para verificar se todas as dependências estão resolvidas.

### Passo 4: Executando o Sistema
- No Visual Studio, selecione **Iniciar** para rodar o projeto. Certifique-se de que o servidor MySQL no XAMPP esteja em execução durante o uso do sistema.

---

## Uso do Sistema

Após executar o sistema, você terá acesso às seguintes seções:

1. **Cadastros**: Adicione e gerencie funcionários, hóspedes, quartos, produtos, entre outros.
2. **Movimentações**: Registre e consulte vendas e serviços.
3. **Reservas**: Gerencie reservas de quartos, incluindo visualização de quartos disponíveis e consulta de reservas.
4. **Relatórios**: Geração de relatórios com opção de exportação para PDF, Excel e Word.

---

## Tecnologias Utilizadas

- **Linguagem de Programação**: C#
- **Banco de Dados**: MySQL (utilizando PHPMyAdmin para gestão)
- **IDE**: Visual Studio
- **Framework**: .NET Windows Forms

---

## Contato

Caso tenha alguma dúvida ou precise de suporte, entre em contato:

- **WhatsApp**: +55 48 99160-4054
- **E-mail**: alexandreliberatto@gmail.com
- **Portfólio**: [Portfolio Online](https://portfolio-alexandre-jade.vercel.app/)
- **LinkedIn**: [Perfil LinkedIn](https://www.linkedin.com/in/alexandre-liberato-32179624b/)

---

Este sistema foi desenvolvido com dedicação e foco na prática das habilidades adquiridas ao longo do curso de Análise e Desenvolvimento de Sistemas da UNISENAI. Agradeço aos professores da instituição por proporcionar este desafio e a oportunidade de crescimento como programador, permitindo-me aplicar e aprimorar conhecimentos em desenvolvimento de software, gestão de dados e resolução de problemas práticos.

Espero que este projeto atenda às necessidades de gestão de uma pousada e demonstre meu compromisso em desenvolver soluções completas e funcionais para o setor de hospedagem.
