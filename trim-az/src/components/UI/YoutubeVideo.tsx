type PropsType = {
    videoId: string;
};

const YoutubeVideo = (props: PropsType) => (
    <iframe
        src={`https://www.youtube.com/embed/${props.videoId}`}
        title="YouTube video player"
        frameBorder="0"
        allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
        allowFullScreen
    />
);

export default YoutubeVideo;
