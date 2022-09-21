import LightGallery from "lightgallery/react";
import Column from "./grid/Column";
import Row from "./grid/Row";

import "lightgallery/css/lightgallery.css";
import "lightgallery/css/lg-zoom.css";
import "lightgallery/css/lg-thumbnail.css";

import lgThumbnail from "lightgallery/plugins/thumbnail";
import lgZoom from "lightgallery/plugins/zoom";

type ImageType = {
    id: string | number;
    src: any;
    alt?: string;
};

type PropsType = {
    images: ImageType[];
};

const Gallery = (props: PropsType) => {
    const onInit = () => {
        console.log("lightGallery has been initialized");
    };

    if (props.images.length === 1) {
        return (
            <LightGallery
                onInit={onInit}
                speed={500}
                plugins={[lgThumbnail, lgZoom]}
                selector={".gallery_item"}
            >
                <div className="gallery">
                    <Row>
                        <Column>
                            <div className="gallery_item_holder single">
                                <div
                                    className="gallery_item"
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
        );
    }

    if (props.images.length === 2) {
        return (
            <LightGallery
                onInit={onInit}
                speed={500}
                plugins={[lgThumbnail, lgZoom]}
                selector={".gallery_item"}
            >
                <div className="gallery">
                    <Row>
                        <Column default={6} sm={6} md={6} lg={6} xl={6}>
                            <div className="gallery_item_holder single">
                                <div
                                    className="gallery_item"
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
                        <Column default={6} sm={6} md={6} lg={6} xl={6}>
                            <div className="gallery_item_holder single">
                                <div
                                    className="gallery_item"
                                    data-src={props.images[1].src}
                                >
                                    <img
                                        src={props.images[1].src}
                                        alt={
                                            props.images[1].alt ??
                                            "Gallery image"
                                        }
                                    />
                                </div>
                            </div>
                        </Column>
                    </Row>
                </div>
            </LightGallery>
        );
    }

    if (props.images.length === 3) {
        return (
            <LightGallery
                onInit={onInit}
                speed={500}
                plugins={[lgThumbnail, lgZoom]}
                selector={".gallery_item"}
            >
                <div className="gallery">
                    <Row>
                        <Column default={6} sm={6} md={6} lg={6} xl={6}>
                            <div className="gallery_item_holder">
                                <div
                                    className="gallery_item"
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
                                <div
                                    className="gallery_item"
                                    data-src={props.images[1].src}
                                >
                                    <img
                                        src={props.images[1].src}
                                        alt={
                                            props.images[1].alt ??
                                            "Gallery image"
                                        }
                                    />
                                </div>
                            </div>
                        </Column>
                        <Column default={6} sm={6} md={6} lg={6} xl={6}>
                            <div className="gallery_item_holder single">
                                <div
                                    className="gallery_item"
                                    data-src={props.images[2].src}
                                >
                                    <img
                                        src={props.images[2].src}
                                        alt={
                                            props.images[2].alt ??
                                            "Gallery image"
                                        }
                                    />
                                </div>
                            </div>
                        </Column>
                    </Row>
                </div>
            </LightGallery>
        );
    }

    if (props.images.length === 4) {
        return (
            <LightGallery
                onInit={onInit}
                speed={500}
                plugins={[lgThumbnail, lgZoom]}
                selector={".gallery_item"}
            >
                <div className="gallery">
                    <Row>
                        <Column default={6} sm={6} md={6} lg={6} xl={6}>
                            <div className="gallery_item_holder">
                                <div
                                    className="gallery_item"
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
                                <div
                                    className="gallery_item"
                                    data-src={props.images[1].src}
                                >
                                    <img
                                        src={props.images[1].src}
                                        alt={
                                            props.images[1].alt ??
                                            "Gallery image"
                                        }
                                    />
                                </div>
                            </div>
                        </Column>
                        <Column default={6} sm={6} md={6} lg={6} xl={6}>
                            <div className="gallery_item_holder">
                                <div
                                    className="gallery_item"
                                    data-src={props.images[2].src}
                                >
                                    <img
                                        src={props.images[2].src}
                                        alt={
                                            props.images[2].alt ??
                                            "Gallery image"
                                        }
                                    />
                                </div>
                                <div
                                    className="gallery_item"
                                    data-src={props.images[3].src}
                                >
                                    <img
                                        src={props.images[3].src}
                                        alt={
                                            props.images[3].alt ??
                                            "Gallery image"
                                        }
                                    />
                                </div>
                            </div>
                        </Column>
                    </Row>
                </div>
            </LightGallery>
        );
    }

    if (props.images.length >= 5) {
        return (
            <LightGallery
                onInit={onInit}
                speed={500}
                plugins={[lgThumbnail, lgZoom]}
                selector={".gallery_item"}
            >
                <div className="gallery">
                    <Row>
                        <Column default={4} sm={4} md={4} lg={4} xl={4}>
                            <div className="gallery_item_holder">
                                <div
                                    className="gallery_item"
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
                                <div
                                    className="gallery_item"
                                    data-src={props.images[1].src}
                                >
                                    <img
                                        src={props.images[1].src}
                                        alt={
                                            props.images[1].alt ??
                                            "Gallery image"
                                        }
                                    />
                                </div>
                            </div>
                        </Column>
                        <Column default={4} sm={4} md={4} lg={4} xl={4}>
                            <div className="gallery_item_holder single">
                                <div
                                    className="gallery_item"
                                    data-src={props.images[2].src}
                                >
                                    <img
                                        src={props.images[2].src}
                                        alt={
                                            props.images[2].alt ??
                                            "Gallery image"
                                        }
                                    />
                                </div>
                            </div>
                        </Column>
                        <Column default={4} sm={4} md={4} lg={4} xl={4}>
                            <div className="gallery_item_holder">
                                <div
                                    className="gallery_item"
                                    data-src={props.images[3].src}
                                >
                                    <img
                                        src={props.images[3].src}
                                        alt={
                                            props.images[3].alt ??
                                            "Gallery image"
                                        }
                                    />
                                </div>
                                <div
                                    className="gallery_item"
                                    data-src={props.images[4].src}
                                >
                                    <img
                                        src={props.images[4].src}
                                        alt={
                                            props.images[4].alt ??
                                            "Gallery image"
                                        }
                                    />
                                </div>
                            </div>
                        </Column>
                    </Row>
                </div>
            </LightGallery>
        );
    }

    return <div></div>;
};

export default Gallery;
