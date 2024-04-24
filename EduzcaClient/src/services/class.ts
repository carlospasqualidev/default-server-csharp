import { api } from "./api";

import { Class } from "@/core/domain/entities/class";

export const createClass = async (data: Class) => {
  return api.post(`/Class`, data);
};
