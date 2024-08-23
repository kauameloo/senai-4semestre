import React from "react";
import { ButtonConfirm, ButtonNew } from "./StyledButtons";

export const Button = ({ text, onClick }) => {
  return <ButtonNew onClick={onClick}>{text}</ButtonNew>;
};

export const ButtonC = ({ text, onClick }) => {
  return <ButtonConfirm onClick={onClick}>{text}</ButtonConfirm>;
};
