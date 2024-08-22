import React, { useState } from "react";
import { ContainerLB, ContainerMain } from "../Containers/StyledContainer";
import { Dates } from "../Date/Dates";
import { SearchBar } from "../SearchBar/SearchBar";
import { Button } from "../Buttons/Buttons";
import { List } from "../Cards/Cards";

const Main = () => {
  const [modalIsOpen, setIsOpen] = useState(false);


  return (
    <ContainerMain>
      <Dates />
      <SearchBar />
      <ContainerLB>
        <List />
        <Button text={"Nova tarefa"}/>
      </ContainerLB>
    </ContainerMain>
  );
};

export default Main;
