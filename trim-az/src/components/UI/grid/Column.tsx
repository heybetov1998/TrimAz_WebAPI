import React from "react";

type Props = {
    default?: number;
    sm?: number;
    md?: number;
    lg?: number;
    xl?: number;
    className?: string;
    children?: React.ReactNode;
};

const Column: React.FC<Props> = (props) => {
    const classes =
        `col-${props.default ?? 12} ` +
        `col-sm-${props.sm ?? 12} ` +
        `col-md-${props.md ?? 12} ` +
        `col-lg-${props.lg ?? 12} ` +
        `col-xl-${props.xl ?? 12} ` +
        `${props.className ?? ""} `;

    return <div className={classes}>{props.children}</div>;
};

export default Column;
