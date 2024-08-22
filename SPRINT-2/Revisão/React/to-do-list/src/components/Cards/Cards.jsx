import React, { useState } from "react";
import styled from "styled-components";
import { FaEdit, FaTrashAlt } from "react-icons/fa"; // Ícones de edição e exclusão

// Array de pessoas (tasks)
const people = [
  "Creola Katherine Johnson: mathematician",
  "Mario José Molina-Pasquel Henríquez: chemist",
  "Mohammad Abdus Salam: physicist",
  "Percy Lavon Julian: chemist",
  "Subrahmanyan Chandrasekhar: astrophysicist",

  // Adicione mais itens aqui
];

// Estilo para o container da lista
const ListContainer = styled.div`
  width: 100%;
  margin-top: 71.76px;
  max-height: 145px;
  overflow-y: auto; /* Adiciona rolagem vertical */
  overflow-x: hidden; /* Impede rolagem horizontal */
  display: flex;
  flex-direction: column;
  gap: 10px; /* Espaçamento entre os cards */
`;

// Componente que renderiza a lista de Cards
export const List = () => {
  return (
    <ListContainer>
      {people.map((person, index) => (
        <Card key={index} text={person} />
      ))}
    </ListContainer>
  );
};

// Estilo para o container do card
const CardContainer = styled.div`
  display: flex;
  align-items: center;
  justify-content: space-between;
  background-color: ${(props) => (props.selected ? "#6C45CE" : "#FCFCFC")};
  border: 1px solid ${(props) => (props.selected ? "#6C45CE" : "#D8D8D8")};
  border-radius: 8px;
  padding: 10px;
  color: ${(props) => (props.selected ? "#FCFCFC" : "#1E123B")};
`;

// Estilo para o checkbox customizado
const CustomCheckbox = styled.div`
  width: 24px;
  height: 24px;
  background-color: ${(props) => (props.checked ? "#1E123B" : "#BDA4FF")};
  border: 2px solid ${(props) => (props.checked ? "#1E123B" : "#BDA4FF")};
  border-radius: 5px;
  display: flex;
  align-items: center;
  justify-content: center;
  cursor: pointer;
  margin-right: 10px;
`;

// Estilo para o ícone de checkmark
const Checkmark = styled.span`
  display: ${(props) => (props.checked ? "block" : "none")};
  width: 12px;
  height: 12px;
  background-color: #fafafa;
  clip-path: polygon(14% 44%, 0% 65%, 50% 100%, 100% 10%, 80% 0%, 43% 72%);
`;

// Estilo para o conteúdo do card
const CardContent = styled.div`
  flex: 1;
`;

// Estilo para os botões de ação
const ActionButtons = styled.div`
  display: flex;
  gap: 10px;
`;

// Estilo para os botões de ação
const IconButton = styled.button`
  background-color: transparent;
  border: 1px solid #1e123b;
  border-radius: 5px;
  padding: 5px;
  cursor: pointer;
  color: #1e123b;

  &:hover {
    background-color: #1e123b;
    color: #fcfcfc;
  }
`;

export const Card = ({ text }) => {
  const [isChecked, setIsChecked] = useState(false);

  const handleCheckboxClick = () => {
    setIsChecked(!isChecked);
  };

  return (
    <CardContainer selected={isChecked}>
      <div style={{ display: "flex", alignItems: "center" }}>
        <CustomCheckbox checked={isChecked} onClick={handleCheckboxClick}>
          <Checkmark checked={isChecked} />
        </CustomCheckbox>
        <CardContent>{text}</CardContent>
      </div>
      <ActionButtons>
        <IconButton>
          <FaEdit />
        </IconButton>
        <IconButton>
          <FaTrashAlt />
        </IconButton>
      </ActionButtons>
    </CardContainer>
  );
};
