# API de Parcerias Locais

## Integrantes do Grupo

- **Allesson Augusto (RM99533)**
- **Cauã Mongs (RM552178)**
- **Erik Teixeira (RM551377)**
- **Guilherme Naoki (RM551456)**
- **Leonardo Gonçalves (RM98912)**

## Descrição da API

A API de Parcerias Locais tem como objetivo gerenciar parcerias com estabelecimentos locais para oferecer ofertas especiais aos usuários. 

### Funcionalidades

- Cadastro e gerenciamento de parceiros (restaurantes, hotéis, atrações turísticas).
- Associação de ofertas especiais a parceiros específicos.
- Consulta de ofertas disponíveis para um itinerário ou localização específica.

## Definição da Arquitetura da API

No desenvolvimento da API de Parcerias Locais, optamos por utilizar uma **arquitetura monolítica**. A decisão por essa abordagem foi fundamentada nas necessidades atuais do projeto e no contexto em que a aplicação está inserida.

### Justificativa da Escolha: Monolítica vs Microservices

1. **Simplicidade e Manutenção**: 
   - A arquitetura monolítica é mais simples de desenvolver e manter, especialmente em estágios iniciais do projeto. Como a aplicação está focada em gerenciar parcerias e ofertas locais, a complexidade ainda é controlada, permitindo uma implementação eficiente em termos de tempo e esforço.

2. **Escalabilidade e Tamanho do Projeto**: 
   - Em comparação com a arquitetura de microservices, a necessidade de escalabilidade e isolamento de serviços não é tão evidente neste momento. Projetos menores, como este, podem se beneficiar de uma aplicação única, pois há menos partes móveis e menos infraestrutura necessária para gerenciar.

3. **Desenvolvimento Rápido**: 
   - O tempo de desenvolvimento em uma arquitetura monolítica é geralmente mais rápido, pois não há necessidade de configurar comunicações entre serviços, comum em microservices. Isso é especialmente importante quando o objetivo é entregar uma aplicação funcional em menos tempo.

## Testes Implementados

A qualidade do código foi assegurada através da implementação de testes unitários, de integração e de sistema utilizando o xUnit. Os testes cobrem as seguintes funcionalidades:

- **Adicionar parceiro**: Testa se um novo parceiro é adicionado corretamente ao banco de dados.
- **Obter parceiro por ID**: Verifica se a busca de um parceiro por ID retorna o parceiro correto.
- **Atualizar parceiro**: Confirma que as alterações em um parceiro são refletidas no banco de dados.
- **Deletar parceiro**: Testa se um parceiro é removido corretamente do banco de dados.

Os testes foram desenvolvidos utilizando um banco de dados em memória para garantir isolamento e rapidez na execução.

## Práticas de Clean Code

Este projeto aplica diversas práticas de Clean Code para garantir um código legível, manutenível e testável, incluindo:

- **Nomes descritivos**: Classes, métodos e variáveis têm nomes que refletem suas responsabilidades.
- **Responsabilidade única**: Cada classe e método é responsável por uma única tarefa, seguindo o princípio da responsabilidade única.
- **Estruturas claras**: O código está organizado em pastas e arquivos com uma estrutura clara, facilitando a navegação.
- **Injeção de dependência**: O uso de injeção de dependência melhora a testabilidade e a flexibilidade do código.

## Funcionalidades de IA Generativa

O projeto incorpora funcionalidades de IA generativa para fornecer recomendações personalizadas de ofertas aos usuários. As principais características incluem:

- **Treinamento de modelo**: Um modelo de Machine Learning é treinado utilizando dados de ofertas para prever quais ofertas são mais relevantes com base nas informações fornecidas pelo usuário.
- **Previsão de ofertas**: O sistema utiliza o modelo treinado para gerar recomendações de ofertas com base na descrição e nos atributos de uma nova oferta.

 ## Instruções para rodar a API:
 
- **Fazer o Download do arquivo .zip no GitHub.
- **Extrair o projeto do arquivo .zip.
- **Abrir o Visual Studio 2022 e em seguida clicar em "abrir um projeto ou uma solução".
- **Aperte o botão de play em cima no seu editor de código
- **Para finalizar, faça os testes no swagger


