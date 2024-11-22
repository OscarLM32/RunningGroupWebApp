import "./AuthImage.css"

function AuthImage(props){
    return(
        <div className="w-100 h-100">
            <img className='auth-image rounded' src={`../../../images/${props.imageName}`} />
            <div className="auth-image-overlay"></div>
            <div className='auth-image-text'>
                <h1 className="text-light">{props.mainText}</h1>
                <p className="text-light text-secondary fs-4">{props.secondaryText}</p>
            </div>
        </div>
    )
}


export default AuthImage;