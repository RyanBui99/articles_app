import React from 'react';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import { Link } from 'react-router-dom';
import IStorageBlogPosts from '../interfaces/IStorageBlogPosts';

interface Prop {
  blogPost: IStorageBlogPosts
}

export default function BlogPosts({blogPost}: Prop) {
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
        src={blogPost.imageSrc}
        alt={blogPost.imageName}
      />
      <CardContent sx={{height: '240px'}}>
        <Typography gutterBottom variant='h5' component='div'>
          {blogPost.header}
        </Typography>
        <Typography variant='body2' color='text.secondary'>
          {blogPost.preview}
        </Typography>
      </CardContent>
      <CardActions>
        <Link to={`/blogPost/${blogPost.id}`} state={blogPost.id}>
          READ FULL ARTICLE
        </Link>
      </CardActions>
    </Card>
  );
}
