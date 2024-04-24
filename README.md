# Bem-vindo à Eduzca !

A Eduzca é uma plataforma dedicada a disponibilizar cursos gratuitos para a comunidade. Nosso objetivo é fornecer acesso igualitário à educação, permitindo que todos contribuam e se beneficiem do aprendizado colaborativo. Na Eduzca, todos são bem-vindos, independentemente de sua origem, nível de habilidade ou recursos financeiros.

Nossa missão é impulsionar o desenvolvimento pessoal e profissional de nossos usuários, promovendo um ambiente de aprendizado inclusivo e colaborativo. Acreditamos que o conhecimento é uma ferramenta poderosa para promover mudanças positivas em nossas vidas e comunidades.

Na Eduzca, você não só pode acessar uma ampla variedade de cursos gratuitos, mas também pode contribuir para a plataforma compartilhando seu próprio conhecimento. Seja um especialista em sua área ou alguém apaixonado por um assunto específico, você pode criar e disponibilizar seus próprios cursos para beneficiar a comunidade como um todo.

Além disso, incentivamos a interação entre os usuários através do sistema de feedback. Ao concluir um curso, você pode fornecer feedback valioso para o instrutor, ajudando a melhorar a qualidade do conteúdo e aprimorar a experiência de aprendizado para outros alunos.

A gestão de cursos na Eduzca é simples e intuitiva. Os instrutores podem facilmente adicionar e organizar aulas, criar conteúdo envolvente e acompanhar o progresso dos alunos. Nossa plataforma foi projetada para ser acessível e fácil de usar, permitindo que tanto os criadores de cursos quanto os alunos se concentrem no que realmente importa: o aprendizado.

Em resumo, a Eduzca não é apenas uma plataforma de cursos online; é uma comunidade vibrante e colaborativa dedicada ao aprendizado contínuo e ao crescimento pessoal. Junte-se a nós hoje e comece sua jornada de aprendizado em um ambiente acolhedor e inspirador.

# Ferramentas Utilizadas

**Tecnologias Principais:**
- **.NET Core 3.1:** O framework principal utilizado para o desenvolvimento da plataforma.
- **Entity Framework Core:** Utilizado para mapeamento objeto-relacional (ORM) e acesso a dados.
- **Entity Framework Core Design e Tools:** Ferramentas usadas para criação e migração de banco de dados.
- **PostgreSQL:** Banco de dados relacional utilizado para armazenar os dados da aplicação.
- **BCrypt:** Utilizado para a criptografia segura das senhas dos usuários.

**Arquitetura em Camadas:**
A aplicação segue uma arquitetura em camadas, o que promove uma separação clara de responsabilidades e facilita a manutenção e escalabilidade do código.
- **Camada de Controller:** Responsável pela interação com as requisições HTTP e pela comunicação com as outras camadas.
- **Camada de Service:** Contém a lógica de negócios da aplicação, incluindo regras de negócios e processamento de dados.
- **Camada de Repositories:** Responsável pelo acesso aos dados, realizando operações de leitura e escrita no banco de dados.
- **Camada de Entities:** Define as entidades de domínio da aplicação, que representam os objetos do mundo real e suas relações.
- **Camada de DTOs (Data Transfer Objects):** Utilizada para transferir dados entre as camadas da aplicação, garantindo a segurança e a eficiência das operações.

# Requisitos Funcionais:

1. **Autenticação e Autorização:**
   - Os usuários devem ser capazes de se registrar e fazer login na plataforma.
   - A autenticação deve ser segura e protegida por senha.
   - A autorização deve garantir que apenas usuários autenticados possam criar cursos, aulas e fornecer feedback.

2. **Gestão de Usuários:**
   - Os usuários devem poder atualizar suas informações de perfil.
   - Os administradores devem poder gerenciar contas de usuário, incluindo a suspensão ou exclusão, se necessário.

3. **Gestão de Cursos:**
   - Os usuários devem ser capazes de criar novos cursos.
   - Os cursos devem ter um nome e, opcionalmente, uma descrição e uma imagem de miniatura.
   - Os criadores de cursos devem poder adicionar aulas aos cursos existentes.
   - Os cursos podem ser marcados como publicados ou não publicados.
   - Os cursos devem exibir uma média de nota baseada nos feedbacks recebidos.

4. **Gestão de Aulas:**
   - Os criadores de cursos devem poder adicionar aulas aos cursos.
   - Cada aula deve ter um nome, uma descrição, um texto e/ou um vídeo.
   - As aulas devem ser organizadas em ordem definida pelo criador do curso.

5. **Feedback do Curso:**
   - Os usuários devem poder fornecer feedback para os cursos que concluíram.
   - O feedback deve incluir uma nota e, opcionalmente, um comentário.
   - O feedback do curso deve ser refletido na média de nota do curso.

# Requisitos Não Funcionais:

1. **Segurança:**
   - Os dados do usuário devem ser armazenados de forma segura.
   - As comunicações entre o cliente e o servidor devem ser criptografadas.
   - Deve haver medidas de proteção contra ataques de injeção SQL e Cross-Site Scripting (XSS).

2. **Desempenho:**
   - O sistema deve ser capaz de lidar com múltiplos usuários simultâneos sem degradação significativa do desempenho.
   - Os tempos de resposta para solicitações de usuário devem ser rápidos, mesmo durante períodos de pico.

3. **Escalabilidade:**
   - O sistema deve ser escalável para lidar com um aumento no número de usuários e cursos sem comprometer o desempenho.

4. **Usabilidade:**
   - A interface do usuário deve ser intuitiva e fácil de usar para usuários de diferentes níveis de habilidade.
   - Deve haver suporte para diferentes dispositivos, incluindo desktops, tablets e smartphones.

5. **Disponibilidade:**
   - O sistema deve estar disponível a maior parte do tempo, com um tempo de inatividade mínimo para manutenção programada.
