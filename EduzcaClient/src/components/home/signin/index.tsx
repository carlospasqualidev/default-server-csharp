"use client";

import React from "react";

import { useRouter } from "next/navigation";

import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";

const SignIn: React.FC = () => {
  const router = useRouter();

  const onSignIn = () => {
    router.push("/dashboard");
  };

  return (
    <div className="flex flex-col gap-4">
      <Input type="email" placeholder="E-mail" />
      <Input type="password" placeholder="Senha" />

      <Button onClick={onSignIn}>Entrar</Button>
    </div>
  );
};

export default SignIn;
