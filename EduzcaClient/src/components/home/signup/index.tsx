import React from "react";

import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";

const SignUp: React.FC = () => {
  return (
    <div className="flex flex-col gap-4">
      <Input type="text" placeholder="Nome" />
      <Input type="email" placeholder="E-mail" />
      <Input type="password" placeholder="Senha" />

      <Button>Cadastrar</Button>
    </div>
  );
};

export default SignUp;
