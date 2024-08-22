import styled from "styled-components";

export const Container = styled.div`
  width: 100%;
  height: 100%;
  margin: 0;
`;

export const ContainerMain = styled.div`
  width: 743.81px;
  height: 495.36px;
  background-color: #1e123b;
  border-radius: 7.72px;
  overflow: hidden; /* Previne que o conteúdo ultrapasse o limite */
  display: flex;
  flex-direction: column;
  align-items: center;
  position: relative;
`;

export const ListContainer = styled.div`
  width: 100%;
  margin-top: 71.76px;
  max-height: 145px;
  overflow-y: auto; /* Adiciona rolagem se necessário */
  overflow-x: hidden; /* Impede rolagem horizontal */
  display: flex;
  flex-direction: column;
  gap: 10px; /* Espaçamento entre os cards */
`;

export const ContainerLB = styled.div`
  width: 90%;
  display: flex;
  flex-direction: column;
  align-items: flex-end;
`;

export const SearchContainer = styled.div`
  position: relative;
  width: 308.64px;
  height: 42.44px;
  display: flex;
  align-items: center;
  justify-content: center;
`;
