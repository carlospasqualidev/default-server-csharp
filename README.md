## Requisitos Funcionais:

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

## Requisitos Não Funcionais:

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
