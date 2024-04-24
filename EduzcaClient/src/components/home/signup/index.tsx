"use client";

import React from "react";

import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";

import { User } from "@/core/domain/entities/user";

import * as AuthService from "@/services/auth";

const SignUp: React.FC = () => {
  const [form, setForm] = React.useState<User>({
    name: "",
    email: "",
    password: "",
  });
  const [loading, setLoading] = React.useState(false);

  const onChange = (
    key: keyof User,
    e: React.ChangeEvent<HTMLInputElement>
  ) => {
    setForm({ ...form, [key]: e.target.value });
  };

  const onSignUp = async () => {
    try {
      setLoading(true);
      const response = await AuthService.signUp(form);
    } catch (error) {
      console.error(error);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="flex flex-col gap-4">
      <Input
        type="text"
        placeholder="Nome"
        onChange={(event) => onChange("name", event)}
      />
      <Input
        type="email"
        placeholder="E-mail"
        onChange={(event) => onChange("email", event)}
      />
      <Input
        type="password"
        placeholder="Senha"
        onChange={(event) => onChange("password", event)}
      />

      <Button onClick={onSignUp} disabled={loading}>
        Cadastrar
      </Button>
    </div>
  );
};

export default SignUp;
