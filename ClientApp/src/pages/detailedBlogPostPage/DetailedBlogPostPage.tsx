import Card from '@mui/material/Card';
import Grid from '@mui/material/Grid';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import React from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import NavbarComponent from '../../components/NavbarComponent';
import IconButton from '@mui/material/IconButton';
import ModeEditOutlineOutlinedIcon from '@mui/icons-material/ModeEditOutlineOutlined';
import DeleteOutlinedIcon from '@mui/icons-material/DeleteOutlined';
import { APIService } from '../../helpers/APIService';
import { useDispatch } from 'react-redux';
import { useTypedSelector } from '../../hooks/useTypeSelector';
import { getClickedBlogPost } from '../../store/actionCreators/blogPostCreator';
import Container from '@mui/material/Container';
import EditBlogPostModal from '../../components/modals/EditBlogPostModal';

export default function DetailedBlogPostPage() {
  const [open, setOpen] = React.useState(false);
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const { blogPost } = useTypedSelector((state) => state.blogPosts);
  const blogPostId: any = useLocation().state;

  React.useEffect(() => {
    dispatch(getClickedBlogPost(blogPostId));
  }, [dispatch]);

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const deleteBlogPost = async () => {
    await APIService.deleteBlogPost(blogPostId);
    navigate('/');
  };

  return (
    <>
      <NavbarComponent />
      <Container
        component='main'
        sx={{
          display: 'flex',
          justifyContent: 'center',
        }}
        maxWidth='xl'
      >
        <Grid container>
          <Card
            sx={{
              boxShadow: 'none',
              borderRadius: '0',
            }}
          >
            <CardMedia
              component='img'
              height='280'
              src={blogPost.imageSrc}
              alt={blogPost.imageName}
            />
            <CardContent>
              <CardActions
                sx={{
                  display: 'flex',
                  justifyContent: 'space-between',
                  alignItems: 'baseline',
                }}
              >
                <Typography
                  gutterBottom
                  variant='h5'
                  component='div'
                  sx={{ display: 'flex', justifyContent: 'center' }}
                >
                  {blogPost.header}
                </Typography>
                <CardActions>
                  <IconButton onClick={handleClickOpen} sx={{ padding: '0' }}>
                    <ModeEditOutlineOutlinedIcon color='primary' />
                  </IconButton>
                  <IconButton onClick={deleteBlogPost} sx={{ padding: '0' }}>
                    <DeleteOutlinedIcon color='error' />
                  </IconButton>
                </CardActions>
              </CardActions>

              <Typography variant='body2' color='text.secondary'>
                {blogPost.content}
              </Typography>
            </CardContent>
          </Card>
        </Grid>
        <EditBlogPostModal handleclose={handleClose} open={open} blogPost={blogPost} />
      </Container>
    </>
  );
}
