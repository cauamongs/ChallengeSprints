Integrantes do grupo

Allesson Augusto (RM99533): 

Cauã Mongs (RM552178): 

Erik Teixeira (RM551377): 

Guilherme Naoki (RM551456): 

Leonardo Gonçalves (RM98912): 

Descrição da API: API de Parcerias Locais Objetivo: Gerenciar parcerias com estabelecimentos locais para oferecer ofertas especiais aos usuários. Funcionalidades: Cadastro e gerenciamento de parceiros (restaurantes, hotéis, atrações turísticas). Associar ofertas especiais a parceiros específicos. Consulta de ofertas disponíveis para um itinerário ou localização específica.

Definição da Arquitetura da API: No desenvolvimento da API de Parcerias Locais, optamos por utilizar uma arquitetura monolítica. A decisão por essa abordagem foi fundamentada nas necessidades atuais do projeto e no contexto em que a aplicação está inserida.

Justificativa da Escolha: Monolítica vs Microservices Simplicidade e Manutenção: A arquitetura monolítica é mais simples de desenvolver e manter, especialmente em estágios iniciais do projeto. Como a aplicação está focada em gerenciar parcerias e ofertas locais, a complexidade ainda é controlada, o que permite que uma abordagem monolítica seja mais eficiente em termos de tempo e esforço de implementação.

Escalabilidade e Tamanho do Projeto: Em comparação com a arquitetura de microservices, que seria recomendada para sistemas maiores e mais distribuídos, a necessidade de escalabilidade e isolamento de serviços não é tão evidente neste momento. Projetos menores como este podem se beneficiar de uma aplicação única, pois há menos partes móveis e menos infraestrutura necessária para gerenciar.

Desenvolvimento Rápido: O tempo de desenvolvimento em uma arquitetura monolítica é geralmente mais rápido, pois não há necessidade de configurar comunicações entre serviços, o que é comum em microservices. Isso é especialmente importante quando o objetivo é entregar uma aplicação funcional em menos tempo.
