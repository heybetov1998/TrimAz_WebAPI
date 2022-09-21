import LightGallery from "lightgallery/react";
import SectionPartName from "../UI/section/SectionPartName";

import "lightgallery/css/lightgallery.css";
import "lightgallery/css/lg-zoom.css";
import "lightgallery/css/lg-thumbnail.css";

import lgThumbnail from "lightgallery/plugins/thumbnail";
import lgZoom from "lightgallery/plugins/zoom";
import Column from "../UI/grid/Column";
import Row from "../UI/grid/Row";

type PropsType = {
    images: {
        src: any;
        alt?: string;
    }[];
};

const Portfolio = (props: PropsType) => {
    const initHandler = () => {
        console.log("Light Gallery is initialized");
    };

    return (
        <div className="portfolio">
            <SectionPartName text="My Portfolio" className="mt-0"/>
            <LightGallery
                onInit={initHandler}
                speed={500}
                plugins={[lgThumbnail, lgZoom]}
                selector={".portfolio_item"}
            >
                <div className="portfolio_images">
                    <Row>
                        <Column default={6} sm={4} md={4} lg={3} xl={3}>
                            <div className="d-flex justify-content-center">
                                <div
                                    className="portfolio_item"
                                    data-src={props.images[0].src}
                                >
                                    <img
                                        src={props.images[0].src}
                                        alt={
                                            props.images[0].alt ??
                                            "Gallery image"
                                        }
                                    />
                                </div>
                            </div>
                        </Column>
                        <Column default={6} sm={4} md={4} lg={3} xl={3}>
                            <div className="d-flex justify-content-center">
                                <div
                                    className="portfolio_item"
                                    data-src={props.images[0].src}
                                >
                                    <img
                                        src={props.images[0].src}
                                        alt={
                                            props.images[0].alt ??
                                            "Gallery image"
                                        }
                                    />
                                </div>
                            </div>
                        </Column>
                        <Column default={6} sm={4} md={4} lg={3} xl={3}>
                            <div className="d-flex justify-content-center">
                                <div
                                    className="portfolio_item"
                                    data-src={props.images[0].src}
                                >
                                    <img
                                        src={props.images[0].src}
                                        alt={
                                            props.images[0].alt ??
                                            "Gallery image"
                                        }
                                    />
                                </div>
                            </div>
                        </Column>
                        <Column default={6} sm={4} md={4} lg={3} xl={3}>
                            <div className="d-flex justify-content-center">
                                <div
                                    className="portfolio_item"
                                    data-src={props.images[0].src}
                                >
                                    <img
                                        src={props.images[0].src}
                                        alt={
                                            props.images[0].alt ??
                                            "Gallery image"
                                        }
                                    />
                                </div>
                            </div>
                        </Column>
                        <Column default={6} sm={4} md={4} lg={3} xl={3}>
                            <div className="d-flex justify-content-center">
                                <div
                                    className="portfolio_item"
                                    data-src={props.images[0].src}
                                >
                                    <img
                                        src={props.images[0].src}
                                        alt={
                                            props.images[0].alt ??
                                            "Gallery image"
                                        }
                                    />
                                </div>
                            </div>
                        </Column>
                        <Column default={6} sm={4} md={4} lg={3} xl={3}>
                            <div className="d-flex justify-content-center">
                                <div
                                    className="portfolio_item"
                                    data-src={props.images[0].src}
                                >
                                    <img
                                        src={props.images[0].src}
                                        alt={
                                            props.images[0].alt ??
                                            "Gallery image"
                                        }
                                    />
                                </div>
                            </div>
                        </Column>
                        <Column default={6} sm={4} md={4} lg={3} xl={3}>
                            <div className="d-flex justify-content-center">
                                <div
                                    className="portfolio_item"
                                    data-src={props.images[0].src}
                                >
                                    <img
                                        src={props.images[0].src}
                                        alt={
                                            props.images[0].alt ??
                                            "Gallery image"
                                        }
                                    />
                                </div>
                            </div>
                        </Column>
                        <Column default={6} sm={4} md={4} lg={3} xl={3}>
                            <div className="d-flex justify-content-center">
                                <div
                                    className="portfolio_item"
                                    data-src={props.images[0].src}
                                >
                                    <img
                                        src={props.images[0].src}
                                        alt={
                                            props.images[0].alt ??
                                            "Gallery image"
                                        }
                                    />
                                </div>
                            </div>
                        </Column>
                    </Row>
                </div>
            </LightGallery>
        </div>
    );
};

export default Portfolio;
