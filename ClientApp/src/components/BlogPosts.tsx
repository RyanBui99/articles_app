import React from 'react';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';

export default function BlogPosts(props: any) {
  

  return (
    <Card
      sx={{
        height: 390,
        maxWidth: 345,
        maxHeight: 390,
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'space-between'
      }}
    >
      <CardMedia
        component='img'
        height='140'
        src={props.blogPost.imageSrc}
        alt={props.blogPost.imageName}
      />
      <CardContent>
        <Typography gutterBottom variant='h5' component='div'>
          {props.blogPost.header}
        </Typography>
        <Typography variant='body2' color='text.secondary'>
          {props.blogPost.preview}
        </Typography>
      </CardContent>
      <CardActions>
        <Button size='small'>Read full article</Button>
      </CardActions>
    </Card>
  );
}
