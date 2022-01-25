import React from 'react';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import { Link } from 'react-router-dom';

export default function BlogPosts(props: any) {
  return (
    <Card
      sx={{
        margin: 'auto',
        height: '418px',
      }}
    >
      <CardMedia
        component='img'
        height='140'
        src={props.blogPost.imageSrc}
        alt={props.blogPost.imageName}
      />
      <CardContent sx={{height: '240px'}}>
        <Typography gutterBottom variant='h5' component='div'>
          {props.blogPost.header}
        </Typography>
        <Typography variant='body2' color='text.secondary'>
          {props.blogPost.preview}
        </Typography>
      </CardContent>
      <CardActions>
        <Link to={`/blogPost/${props.blogPost.id}`} state={props.blogPost.id}>
          READ FULL ARTICLE
        </Link>
      </CardActions>
    </Card>
  );
}
