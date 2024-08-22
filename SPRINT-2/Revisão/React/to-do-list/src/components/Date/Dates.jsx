import React from "react";
import styled from "styled-components";
import "./Dates.css";

export const Dates = () => {
  const now = new Date();

  const dayName = new Array(
    "Domingo",
    "Segunda-Feira",
    "Terça-Feira",
    "Quarta-Feira",
    "Quinta-Feira",
    "Sexta-Feira",
    "Sábado"
  );
  const monName = new Array(
    "Janeiro",
    "Fevereiro",
    "Março",
    "Abril",
    "Maio",
    "Junho",
    "Julho",
    "Agosto",
    "Outubro",
    "Novembro",
    "Dezembro"
  );
  return (
    <h1 className="color-text">
      {dayName[now.getDay()]},{" "}
      <span style={{ color: "#8758FF" }}>{now.getDate()}</span> de{" "}
      {monName[now.getMonth()]}
    </h1>
  );
};
