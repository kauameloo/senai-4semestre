import React from "react";
import Modal from "react-modal";
import "./ModalNewTask.css";
import styled from "styled-components";
import { ButtonC } from "../Buttons/Buttons";

const TitleText = styled.h1`
  font-size: 32px;
`;

const DescriptionInput = styled.textarea`
  width: 577px;
  height: 177px;
  background-color: #1e123b;
  border: 2px solid #fcfcfc;
  border-radius: 10px;
  padding: 10px 12px; /* Alinha o texto à esquerda e no topo */
  resize: none; /* Impede redimensionamento do textarea */
  text-align: left;
  font-size: 18px;
  font-weight: 500;
  color: #fcfcfc;

  margin-top: 37px;

  textarea::placeholder {
    color: #fcfcfc;
    opacity: 1;
  }
`;

export const ModalNewTask = ({ isOpen }) => {
  return (
    <Modal isOpen={isOpen} className="Modal" overlayClassName="Overlay">
      <TitleText>Descreva sua tarefa</TitleText>
      <DescriptionInput placeholder="Descreva sua tarefa" />
      <ButtonC text={"Confirmar sua tarefa"} />
    </Modal>
  );
};
