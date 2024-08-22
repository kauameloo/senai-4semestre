import React from "react";
import { ButtonNew } from "./StyledButtons";

export const Button = ({ text, onClick }) => {
  return <ButtonNew onClick={onClick}>{text}</ButtonNew>;
};
