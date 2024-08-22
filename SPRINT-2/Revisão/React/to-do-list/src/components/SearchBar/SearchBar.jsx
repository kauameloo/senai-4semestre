import React, { useState } from "react";
import styled from "styled-components";
import { SearchContainer } from "../Containers/StyledContainer";
import searchIcon from "../../assets/material-symbols_search.svg";

const SearchStyle = styled.input`
  width: 100%;
  height: 100%;
  border: 1.54px solid #fcfcfc;
  border-radius: 7.72px;
  background-color: #1e123b;
  padding-left: 40px;
  padding-right: 110px;
  color: #fcfcfc;
`;

// Estilo para a imagem dentro do input
const Icon = styled.img`
  position: absolute;
  left: 10px; /* Posiciona a imagem à esquerda */
  top: 50%;
  transform: translateY(-50%);
  width: 20px;
  height: 100%;
`;

// Estilo para o texto adicional dentro do input
const TextInside = styled.button`
  position: absolute;
  right: 10px; /* Posiciona o texto à direita */
  top: 46%;
  transform: translateY(-50%);
  color: #fcfcfc;
  font-size: 14px;
  background-color: transparent;
  outline: none;
  border: none;
  height: 100%;

  &:focus {
    outline: none;
  }

  &:hover {
    outline: none;
  }
  padding: 0;
`;

export const SearchBar = ({ inputText }) => {
  const [searchText, setSearchText] = useState(inputText || "");

  const handleChange = (event) => {
    setSearchText(event.target.value);
  };

  return (
    <SearchContainer>
      <Icon src={searchIcon} alt="Search icon" />
      <SearchStyle
        type="text"
        value={searchText}
        onChange={handleChange}
        placeholder=""
      ></SearchStyle>
      <TextInside>Procurar tarefa</TextInside>{" "}
    </SearchContainer>
  );
};
