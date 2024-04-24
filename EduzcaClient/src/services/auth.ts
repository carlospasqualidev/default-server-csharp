import { api } from "./api";

import type { User } from "@/core/domain/entities/user";

export const signUp = async (data: User) => {
  return api.post("/Auth/Register", data);
};
