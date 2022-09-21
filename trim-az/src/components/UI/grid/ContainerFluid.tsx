import React from "react";

type Props = {
    children?: React.ReactNode;
};

const ContainerFluid: React.FC<Props> = (props) => {
    return <div className="container-fluid">{props.children}</div>;
};

export default ContainerFluid;
